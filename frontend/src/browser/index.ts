import { ChromeBrowserManager } from './ChromeBrowserManager';
import { IBrowserManager } from './IBrowserManager';

export const browserManager: IBrowserManager = new ChromeBrowserManager();