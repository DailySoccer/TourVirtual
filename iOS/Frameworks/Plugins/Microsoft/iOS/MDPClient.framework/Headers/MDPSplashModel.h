//
//  MDPSplashModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSplashModel.h"


#pragma mark - Interface
@interface MDPSplashModel : _MDPSplashModel

+ (NSArray *)splashItemsWithAppId:(NSString *)appId country:(NSString *)country managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSplashWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
