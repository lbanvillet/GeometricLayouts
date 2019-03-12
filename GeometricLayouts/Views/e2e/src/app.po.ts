import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get(browser.baseUrl) as Promise<any>;
  }

  getNameFormButtonText() {
    return element(by.css('app-root app-triangle-generator form button')).getText() as Promise<string>;
  }
}
