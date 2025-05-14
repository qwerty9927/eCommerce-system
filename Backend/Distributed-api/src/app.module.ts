import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { AppService } from './app.service';
import { AppController } from './app.controller';
import { RedisConfig } from './configurations/redis.config';
import { RedisModule } from './modules/redis/redis.module';
import { SharedModule } from './modules/shared.module';
import { CacheModule } from './modules/caching/cache.module';
import KeyvRedis from '@keyv/redis';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      envFilePath: `.env.${process.env.NODE_ENV || 'development'}`,
      cache: false,
    }),

    CacheModule.registerAsync(() => {
      const redisConfig = JSON.parse(process.env.REDIS_CONFIG) as RedisConfig;
      const redisClient = new KeyvRedis({ url: `redis://${redisConfig.host}:${redisConfig.port}` });

      return new Map([[{ store: redisClient }, { namespace: null, ttl: 1000 * 60 * 60 }]]);
    }),

    RedisModule,
    SharedModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
