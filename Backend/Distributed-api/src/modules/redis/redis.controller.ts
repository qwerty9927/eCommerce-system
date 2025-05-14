import { Body, Controller, Delete, Get, Inject, Param, Post } from '@nestjs/common';
import { RedisService } from './redis.service';
import { RedisConfig } from 'src/configurations/redis.config';
import { ConfigConstant } from 'src/common/constants/config.constant';

@Controller('api/redis')
export class RedisController {
  constructor(
    @Inject(ConfigConstant.REDIS_CONFIG) private readonly redisConfig: RedisConfig,
    private readonly redisService: RedisService,
  ) {}

  @Get(':key')
  async getValueAsync(@Param('key') key: string): Promise<any> {
    return await this.redisService.getValueAsync(key);
  }

  @Post(':key')
  async setValueAsync(
    @Param('key') key: string,
    @Body('value') value: any,
    @Body('ttl') ttl: number = 0,
  ) {
    return await this.redisService.setValueAsync(key, value, ttl);
  }

  @Delete(':key')
  async deleteKeyAsync(@Param('key') key: string) {
    return await this.redisService.deleteKeyAsync(key);
  }

  @Delete('all')
  async clearAllAsync() {
    return await this.redisService.clearAllAsync();
  }
}
