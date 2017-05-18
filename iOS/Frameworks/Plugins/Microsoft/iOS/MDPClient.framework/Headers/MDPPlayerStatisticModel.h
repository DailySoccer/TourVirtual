//
//  MDPPlayerStatisticModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlayerStatisticModel.h"


#pragma mark - PlayerStatiticsPosition
typedef NS_ENUM(NSInteger, MDPPlayerStatisticModelPosition ) {
    MDPPlayerStatisticModelPositionUnknow         = 0,
    MDPPlayerStatisticModelPositionGoalkeeper     = 1,
    MDPPlayerStatisticModelPositionDefender       = 2,
    MDPPlayerStatisticModelPositionMidfielder     = 3,
    MDPPlayerStatisticModelPositionStriker        = 4,
} ;


#pragma mark - Interface
@interface MDPPlayerStatisticModel : _MDPPlayerStatisticModel

+ (MDPPlayerStatisticModel *)playerStatisticsWithIdSeason:(NSString *)idSeason
                                            idCompetition:(NSString *)idCompetition
                                                 idPlayer:(NSString *)idPlayer
                                                 language:(NSString *)language
                                     managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPlayerStatisticWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
