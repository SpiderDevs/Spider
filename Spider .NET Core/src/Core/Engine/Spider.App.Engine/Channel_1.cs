using Spider.App.Interfaces;
using Spider.App.Models;
using Spider.Helpers;
using Spider.Interfaces;
using Spider.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Spider.App.Engine
{
    /// <summary>
    /// Important concept info. Read this.
    /// For all methods in services.
    /// 1. All methods should have at least one parameter and max two parameters.
    /// 1. First param should alvays be ServiceContext
    /// 1. Second parameter is defined by user.
    /// 2. One name - one method. We not supoort overloading of functions :( 
    /// </summary>
    public class Channel_1 : IServiceChannel
    {
        private IServiceContext _serviceContext;

        private readonly string[] _registeredServcesInterfaces = new  string[2]
        {
            typeof(ITestService).FullName,
            typeof(IAuthorisationService).FullName
        };
        
        public IServiceResponse Process(IRequest request)
        {
            IService service;
            MethodInfo theMethodToCall;
            try
            {
                //TODO: Add log on method entry - generate guid - and put all of queuses with one quid - quid to service context. Add Measure execution time. Add logging enable/disable. Time measuring disable/enable. Hmmmmm cpu use by method? We can do it?
                init(request);

                service = GetServiceByName(request.Service);

                var serviceInterfaces = service.GetType().GetInterfaces();
                var serviceInterface = GetCorrectedInterface(serviceInterfaces);
                var correctedMethod = GetCorrectedMethodName(serviceInterface, request.Method);
                theMethodToCall = service.GetType().GetMethod(correctedMethod);

            }
            catch (Exception ex)
            {
                //TODO: add log. 

                //Should newer occur. We shoul't show error to protect hack by detailed message, example from database. 
                //Expected erroprs should be wraped by SpiderExceptionBase
                return new ServiceResponse(Message.Error(new Fault("Unexpected error", "Unexpected error when processing. Can't show details.")));
            }
            //TODO: check permissions
            var methodParams = prepareMethodInvokeParams(theMethodToCall, request.Request);
            var result = theMethodToCall.Invoke(service, methodParams);

            IServiceResponse response = new ServiceResponse();
            response.Message = (IMessage)result;
            return response;
        }

        private IService GetServiceByName(string name)
        {
            var serviceName = name.Replace("Service", "");
            return ServicesFactory.Get(serviceName);
        }

        public Type GetCorrectedInterface(Type[] serviceInterfaces)
        {
            foreach(Type serviceInterface in serviceInterfaces)
            {
               var detectedInterface = _registeredServcesInterfaces.Where(x => x.Equals(serviceInterface.FullName)).FirstOrDefault();
                if (detectedInterface != null)
                    return serviceInterface;
            }
            return null;
        }

        public string GetCorrectedMethodName(Type @interface, string methodName)
        {
            return @interface.GetMethods().Where(x => x.Name.ToUpper() == methodName.ToUpper().Trim()).First().Name;
        }

        private void init(IRequest request)
        {
            //I add this params for faster bug tracking. You can remve this from yours Channel
            _serviceContext = ServiceContext.Prepare(request);
        }

        private object[] prepareMethodInvokeParams(MethodInfo theMethodToCall, string param)
        {
            ParameterInfo[] methodParameters = theMethodToCall.GetParameters();
            if (methodParameters.Count() < 1)
            {
                  _serviceContext.LogError(string.Format("Invalid method declaration. Method: {0} have to contain at lest one parameter", theMethodToCall));
            }
            if (methodParameters.Count() > 2)
            {
                 _serviceContext.LogError(string.Format("Invalid method declaration. Method: {0} have to contain maximum two parameters", theMethodToCall));
            }
            if (!((methodParameters[0])).ParameterType.FullName.EndsWith(typeof(IServiceContext).Name))
            {
                 _serviceContext.LogError(string.Format("Invalid method declaration. Method: {0} have to contain IServiceContext as first parameter", theMethodToCall));
            }
            if (!theMethodToCall.ReturnType.Name.EndsWith("IMessage"))
            {
                  _serviceContext.LogError(string.Format("Invalid method declaration. Method: {0} have to return IMessage", theMethodToCall));
            }            

            var result = new object[methodParameters.Count()];
            result[0] = _serviceContext;
            if (methodParameters.Count() == 2)
            {
                var detectedType = methodParameters[1].ParameterType;
                var deserialized = JsonHelper.FromJson(param, detectedType);
                result[1] = deserialized;

                //TODO: If from settings
                var paramObject = Activator.CreateInstance(detectedType);
            }
            return result.ToArray();

        }



    }



}
