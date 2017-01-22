import { SpiderWEBPage } from './app.po';

describe('spider-web App', function() {
  let page: SpiderWEBPage;

  beforeEach(() => {
    page = new SpiderWEBPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
