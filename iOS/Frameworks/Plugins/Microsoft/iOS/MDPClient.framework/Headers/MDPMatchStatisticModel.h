//
//  MDPMatchStatisticModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchStatisticModel.h"


#pragma mark - MDPMatchStatisticModelMatchStatisticType
typedef NS_ENUM(NSInteger, MDPMatchStatisticModelMatchStatisticType) {
    MDPMatchStatisticModelNameTotal_Tackle_Ranking                               = 0,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Tackle                         = 1,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Fouls_Ranking                  = 2,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Fouls                          = 3,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Accurate_Pass_Ranking          = 4,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Accurate_Pass                  = 5,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals_Ranking                  = 6,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals                          = 7,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals_Conceded_Ranking         = 8,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals_Conceded                 = 9,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Scoring_Att_Ranking            = 10,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Scoring_Att                    = 11,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Was_Fouled_Ranking             = 12,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Was_Fouled                     = 13,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Attempts_Conceded_Obox_Ranking = 14,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Attempts_Conceded_Obox         = 15,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Pass_Ranking                   = 16,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Pass                           = 17,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Won_Tackle_Ranking             = 18,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Won_Tackle                     = 19,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals_Conceded_Ibox_Ranking    = 20,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Goals_Conceded_Ibox            = 21,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Attempts_Conceded_Ibox_Ranking = 22,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Attempts_Conceded_Ibox         = 23,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Yellow_Card_Ranking            = 24,
    MDPMatchStatisticModelMatchStatisticTypeTotal_Yellow_Card                    = 25,
};


#pragma mark - Interface
@interface MDPMatchStatisticModel : _MDPMatchStatisticModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
