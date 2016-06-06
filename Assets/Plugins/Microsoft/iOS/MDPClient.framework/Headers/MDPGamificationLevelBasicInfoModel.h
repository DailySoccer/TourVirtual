//
//  MDPGamificationLevelModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPGamificationLevelBasicInfoModel.h"


#pragma mark - Interface
@interface MDPGamificationLevelBasicInfoModel : _MDPGamificationLevelBasicInfoModel

+ (NSArray *)gamificationLevelWithAppId:(NSString *)appId
                               language:(NSString *)language
                   managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithAppId:(NSString *)appId
                       language:(NSString *)language
                     dictionary:(NSDictionary *)dictionary
           managedObjectContext:(NSManagedObjectContext *)context;

@end
