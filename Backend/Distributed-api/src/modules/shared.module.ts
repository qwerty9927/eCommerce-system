import { Global, Module } from '@nestjs/common';
import { ConfigConstant } from 'src/common/constants/config.constant';
import { ConfigProvider } from 'src/common/providers/config.provider';

const services = [ConfigProvider(ConfigConstant.REDIS_CONFIG)];

@Global()
@Module({
  providers: services,
  exports: services,
})
export class SharedModule {}
