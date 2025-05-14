import { Keyv } from '@keyv/redis';
import { DynamicModule, Global, Module } from '@nestjs/common';
import { createCache } from 'cache-manager';
import { InfrastructureConstant } from 'src/common/constants/infrastructure.constant';

type adapter = () => Map<any, any>;

@Global()
@Module({})
export class CacheModule {
  static registerAsync(connectionAdapter: adapter): DynamicModule {
    const provider = {
      provide: InfrastructureConstant.CACHE_MANAGER,
      useFactory: async () => {
        const stores: Keyv[] = [];

        for (const [connection, option] of connectionAdapter()) {
          const keyv = new Keyv(connection, option);

          keyv.on('error', (err) => console.error('Connection error!', err.message));
          keyv.on('clear', () => console.log('Cache Cleared'));
          keyv.on('disconnect', () => console.log('Disconnected'));

          stores.push(keyv);
        }

        return createCache({
          stores,
        });
      },
    };

    return {
      module: CacheModule,
      providers: [provider],
      exports: [provider],
    };
  }
}
