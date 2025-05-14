import { ConfigService } from '@nestjs/config';

export class Config<T> {
  value: T;

  constructor(
    configName: string,
    private readonly configService: ConfigService,
  ) {
    const config = JSON.parse(configService.get(configName)) as T;
    this.value = config;
  }
}
