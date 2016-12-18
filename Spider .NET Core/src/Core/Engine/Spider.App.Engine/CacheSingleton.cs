using Spider.Cache;
using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{  
    public sealed class CacheSingleton
    {
        private static ICacheService m_Instance = null;
        private static readonly object m_Sync = new object();

        private CacheSingleton() { }

        public static ICacheService Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Sync)
                    {
                        if (m_Instance == null)
                            m_Instance = new RedisCacheService();
                    }
                }
                return m_Instance;
            }
        }
    }
}
