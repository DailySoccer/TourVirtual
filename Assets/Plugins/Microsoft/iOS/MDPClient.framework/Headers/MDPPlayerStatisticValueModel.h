//
//  MDPPlayerStatisticValueModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlayerStatisticValueModel.h"


#pragma mark - MDPPlayerStatisticType
typedef NS_ENUM(NSInteger, MDPPlayerStatisticValueModelPlayerStatisticType ) {
    
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Assists_Ranking                   = 0,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Assists                           = 1,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Ontarget_Attempt_Ranking          = 2,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Ontarget_Attempt                  = 3,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Fouls_Ranking                     = 4,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Fouls                             = 5,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Aerial_Lost_Ranking               = 6,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Aerial_Lost                       = 7,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Pass_Ranking             = 8,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Pass                     = 9,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Pass_Ranking                      = 10,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Pass                              = 11,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Freekick_Miss_Ranking         = 12,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Freekick_Miss                 = 13,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Effective_Clearance_Ranking       = 14,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Effective_Clearance               = 15,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Fwd_Zone_Pass_Ranking    = 16,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Fwd_Zone_Pass            = 17,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Tackle_Ranking                    = 18,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Tackle                            = 19,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Was_Fouled_Ranking                = 20,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Was_Fouled                        = 21,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Sub_On_Ranking                    = 22,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Sub_On                            = 23,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Challenge_Lost_Ranking            = 24,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Challenge_Lost                    = 25,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Assist_Ranking                = 26,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Assist                        = 27,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Won_Tackle_Ranking                = 28,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Won_Tackle                        = 29,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Duels_Lost_Ranking                = 30,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Duels_Lost                        = 31,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Fwd_Zone_Pass_Ranking             = 32,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Fwd_Zone_Pass                     = 33,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Won_Contest_Ranking               = 34,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Won_Contest                       = 35,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Back_Zone_Pass_Ranking   = 36,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Back_Zone_Pass           = 37,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Blocked_Scoring_Att_Ranking       = 38,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Blocked_Scoring_Att               = 39,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Interception_Ranking              = 40,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Interception                      = 41,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Goals_Conceded_Ranking            = 42,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Goals_Conceded                    = 43,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Card_Ranking                      = 44,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Card                              = 45,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Freekick_Total_Ranking        = 46,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Att_Freekick_Total                = 47,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempts_Conceded_Obox_Ranking    = 48,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempts_Conceded_Obox            = 49,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Scoring_Att_Ranking               = 50,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Scoring_Att                       = 51,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Crosses_Ranking                   = 52,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Crosses                           = 53,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Clearance_Ranking                 = 54,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Clearance                         = 55,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Duels_Won_Ranking                 = 56,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Duels_Won                         = 57,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempt_Ranking                   = 58,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempt                           = 59,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Sub_Off_Ranking                   = 60,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Sub_Off                           = 61,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Cross_Ranking            = 62,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Cross                    = 63,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Mins_Played_Ranking               = 64,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Mins_Played                       = 65,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempts_Conceded_Ibox_Ranking    = 66,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Attempts_Conceded_Ibox            = 67,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Contest_Ranking                   = 68,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Contest                           = 69,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Long_Balls_Ranking                = 70,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Long_Balls                        = 71,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Games_Ranking                     = 72,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Games                             = 73,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Long_Balls_Ranking       = 74,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Accurate_Long_Balls               = 75,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Aerial_Won_Ranking                = 76,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Aerial_Won                        = 77,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Yellow_Card_Ranking               = 78,
    MDPPlayerStatisticValueModelPlayerStatisticTypeTotal_Yellow_Card                       = 79,
};


#pragma mark - Interface
@interface MDPPlayerStatisticValueModel : _MDPPlayerStatisticValueModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
