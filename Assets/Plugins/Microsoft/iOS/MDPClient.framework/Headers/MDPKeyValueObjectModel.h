//
//  MDPKeyValueObjectModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPKeyValueObjectModel.h"
#import "MDPCompetitionMatchModel.h"


#pragma mark - Interface
@interface MDPKeyValueObjectModel : _MDPKeyValueObjectModel

+ (NSArray *)keyValueObjectWithSportType:(int)sportType managedObjectContext:(NSManagedObjectContext *)context;
+ (NSArray *)keyValueObjectWithIdSeason:(NSString *)idSeason idCompetition:(NSString *)idCompetition sportType:(MDPCompetitionMatchModelSportType)sportType idTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsKeyValueObjectWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsKeyValueObjectWithIdSeason:(NSString *)idSeason
                                              idCompetition:(NSString *)idCompetition
                                                  sportType:(MDPCompetitionMatchModelSportType)sportType
                                                     idTeam:(NSString *)idTeam
                                                 dictionary:(NSDictionary *)dictionary
                                       managedObjectContext:(NSManagedObjectContext *)context;

@end
