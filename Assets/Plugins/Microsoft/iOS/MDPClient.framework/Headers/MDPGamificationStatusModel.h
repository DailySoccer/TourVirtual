//
//  MDPGamificationStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPGamificationStatusModel.h"


#pragma mark  - Interface
@interface MDPGamificationStatusModel : _MDPGamificationStatusModel

+ (MDPGamificationStatusModel *)fanGamificationStatusWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsGamificationStatusWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)gamificationStatusFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
