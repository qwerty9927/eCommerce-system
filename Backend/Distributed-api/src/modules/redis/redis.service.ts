import { Inject, Injectable } from '@nestjs/common';
import { Cache } from 'cache-manager';
import { InfrastructureConstant } from 'src/common/constants/infrastructure.constant';

@Injectable()
export class RedisService {
  constructor(@Inject(InfrastructureConstant.CACHE_MANAGER) private readonly cacheManager: Cache) {}

  async getValueAsync(key: string) {
    return await this.cacheManager.get(key);
  }

  async setValueAsync(key: string, value: any, ttl: number = 0) {
    return await this.cacheManager.set(key, value, ttl);
  }

  async deleteKeyAsync(key: string) {
    return await this.cacheManager.del(key);
  }

  async clearAllAsync() {
    return await this.cacheManager.clear();
  }
}
