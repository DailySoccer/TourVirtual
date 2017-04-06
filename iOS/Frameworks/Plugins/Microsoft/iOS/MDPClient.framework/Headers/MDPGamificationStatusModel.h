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

+ (MDPGamificationStatusModel *)gamificationStatusWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsGamificationStatusWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

// if idUser is nill, it returns all the gamificationStatus
+ (NSFetchedResultsController *)gamificationStatusFetchedResultsControllerWithIdUser:(NSString *)idUser
                                                                managedObjectContext:(NSManagedObjectContext *)context
                                                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
