//
//  MDPBasketLiveMatchPlayerStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPBasketLiveMatchPlayerStatisticsModel.h"

#pragma mark  - BasketLiveMatchPlayerStatusType
typedef NS_ENUM(NSInteger, MDPBasketLiveMatchPlayerStatisticsBasketLiveMatchPlayerStatusType) {
    MDPBasketLiveMatchPlayerStatisticsStatusTypePlaying     = 1,
    MDPBasketLiveMatchPlayerStatisticsStatusTypeBench       = 10,
};


#pragma mark - Interface
@interface MDPBasketLiveMatchPlayerStatisticsModel : _MDPBasketLiveMatchPlayerStatisticsModel

+ (MDPBasketLiveMatchPlayerStatisticsModel *)basketLiveMatchPlayerStatisticsWithIdSeason:idSeason
                                                                           idCompetition:idCompetition
                                                                                 idMatch:(NSString *)idMatch
                                                                                idPlayer:(NSString *)idPlayer
                                                                    managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsBasketLiveMatchPlayerStatisticsWithDictionary:(NSDictionary *)dictionary
                                                          managedObjectContext:(NSManagedObjectContext *)context;

@end
