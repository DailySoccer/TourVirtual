//
//  MDPFootballLiveMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFootballLiveMatchModel.h"


#pragma mark - Interface
@interface MDPFootballLiveMatchModel : _MDPFootballLiveMatchModel

+ (MDPFootballLiveMatchModel *)footballLiveMatchWithIdSeason:(NSString *)idSeason
                                               idCompetition:(NSString *)idCompetition
                                                     idMatch:(NSString *)idMatch
                                        managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFootballLiveMatchWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)footballLiveMatchFetchedResultsControllerWithIdSeason:(NSString *)idSeason
                                                                        idCompetition:(NSString *)idCompetition
                                                                              idMatch:(NSString *)idMatch
                                                                 managedObjectContext:(NSManagedObjectContext *)context
                                                                             delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
