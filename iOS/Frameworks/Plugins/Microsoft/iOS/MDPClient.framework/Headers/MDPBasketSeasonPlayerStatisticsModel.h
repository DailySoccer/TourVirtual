//
//  MDPBasketSeasonPlayerStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPBasketSeasonPlayerStatisticsModel.h"


#pragma mark - Interface
@interface MDPBasketSeasonPlayerStatisticsModel : _MDPBasketSeasonPlayerStatisticsModel

+ (MDPBasketSeasonPlayerStatisticsModel *)basketSeasonPlayerStatisticsWithIdSeason:idSeason idPlayer:(NSString *)idPlayer managedObjectContext:(NSManagedObjectContext *)context;
+ (instancetype)insertIfNotExistsBasketSeasonPlayerStatisticsWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
