//
//  MDPCompetitionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompetitionModel.h"


#pragma mark Competition Type
typedef NS_ENUM(NSUInteger, MDPCompetitionModelCompetitionType) {
    MDPCompetitionModelCompetitionTypeLeague            = 0,
    MDPCompetitionModelCompetitionTypeRounds            = 1,
    MDPCompetitionModelCompetitionTypeLeagueAndRounds   = 2,
    MDPCompetitionModelCompetitionTypeGroupsAndRounds   = 3,
};


#pragma mark - Interface
@interface MDPCompetitionModel : _MDPCompetitionModel

+ (NSArray *)competitionItemsWithIdSeason:(NSString *)idSeason idTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)competitionWithIdCompetition:(NSString *)idCompetition managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary
                                                  idSeason:(NSString *)idSeason
                                                    idTeam:(NSString *)idTeam
                                      managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
