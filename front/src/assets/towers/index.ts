import frontendJunior from './frontend/frontend-junior.svg';
import frontendMiddle from './frontend/frontend-middle.svg';
import frontendSenior from './frontend/frontend-senior.svg';
import backendJunior from './backend/backend-junior.svg';
import backendMiddle from './backend/backend-middle.svg';
import backendSenior from './backend/backend-senior.svg';
import qaJunior from './qa/qa-junior.svg';
import qaMiddle from './qa/qa-middle.svg';
import qaSenior from './qa/qa-senior.svg';
import designJunior from './design/design-junior.svg';
import designMiddle from './design/design-middle.svg';
import designSenior from './design/design-senior.svg';
import analystJunior from './analyst/analyt-junior.svg';
import analystMiddle from './analyst/analyt-middle.svg';
import analystSenior from './analyst/analyt-senior.svg';
import pmJunior from './pm/pm-junior.svg';
import pmMiddle from './pm/pm-middle.svg';
import pmSenior from './pm/pm-senior.svg';

import { DeveloperLevel, TowerType } from '../../Components/Pages/GameLayout/PlayingField/TowersLayer/TowerLayer.types';

export const towers = {
  [TowerType.frontend]: {
    [DeveloperLevel.junior]: frontendJunior,
    [DeveloperLevel.middle]: frontendMiddle,
    [DeveloperLevel.senior]: frontendSenior,
  },
  [TowerType.backend]: {
    [DeveloperLevel.junior]: backendJunior,
    [DeveloperLevel.middle]: backendMiddle,
    [DeveloperLevel.senior]: backendSenior,
  },
  [TowerType.qa]: {
    [DeveloperLevel.junior]: qaJunior,
    [DeveloperLevel.middle]: qaMiddle,
    [DeveloperLevel.senior]: qaSenior,
  },
  [TowerType.designer]: {
    [DeveloperLevel.junior]: designJunior,
    [DeveloperLevel.middle]: designMiddle,
    [DeveloperLevel.senior]: designSenior,
  },
  [TowerType.analyst]: {
    [DeveloperLevel.junior]: analystJunior,
    [DeveloperLevel.middle]: analystMiddle,
    [DeveloperLevel.senior]: analystSenior,
  },
  [TowerType.pm]: {
    [DeveloperLevel.junior]: pmJunior,
    [DeveloperLevel.middle]: pmMiddle,
    [DeveloperLevel.senior]: pmSenior,
  },
};
