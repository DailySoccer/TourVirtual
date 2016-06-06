//
//  MDPCompetitionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompetitionModel.h"

@interface MDPCompetitionModel : _MDPCompetitionModel

+ (NSArray *)competitionItemsWithIdSeason:(NSString *)idSeason idTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)competitionWithIdCompetition:(NSString *)idCompetition managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary
                                                  idSeason:(NSString *)idSeason
                                                    idTeam:(NSString *)idTeam
                                      managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
