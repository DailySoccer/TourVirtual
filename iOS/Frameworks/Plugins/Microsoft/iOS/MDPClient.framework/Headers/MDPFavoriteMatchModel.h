//
//  MDPFavoriteMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFavoriteMatchModel.h"


#pragma mark - Interface
@interface MDPFavoriteMatchModel : _MDPFavoriteMatchModel

+ (instancetype)favoriteMatchWithIdSeason:(NSString *)idSeason idCompetition:(NSString *)idCompetition idMatch:(NSString *)idMatch managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFavoriteMatchWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)favoriteMatchFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

- (BOOL)isStartedMatch;
- (BOOL)isPreMatch;
- (BOOL)isFinishedMatch;

@end
