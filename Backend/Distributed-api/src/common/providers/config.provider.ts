import { ConfigService } from '@nestjs/config';
import { Config } from 'src/configurations/config';
import { Provider, Scope } from '@nestjs/common';

export const ConfigProvider = <T>(configName: string): Provider => {
  return {
    provide: configName,
    useFactory: (configService: ConfigService) => {
      return new Config<T>(configName, configService).value;
    },
    inject: [ConfigService],
    scope: Scope.REQUEST,
  };
};
