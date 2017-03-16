//
//  MDPEventHUBHandler.h
//  MDPClient
//
//  Created by Ivan Cabezon on 17/10/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MDPVideoModel.h"


#pragma mark - Inteface
@interface MDPEventHubHandler : NSObject

+ (MDPEventHubHandler *)sharedInstance;
+ (void)destroyInstance;

- (void)configEventHubWithUrlEventHubPath:(NSString *)urlEventHubPath key:(NSString *)key absolutePathEventHUB:(NSString *)absolutePathEventHUB;

- (void)sendEventWithParams:(MDPVideoModel *)videoModel
            completionBlock:(void (^)(BOOL finishedOk, NSError *error))completionBlock;

@end
