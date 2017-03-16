//
//  MDPPublicGamificationStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPublicGamificationStatusModel.h"


#pragma mark - Interface
@interface MDPPublicGamificationStatusModel : _MDPPublicGamificationStatusModel

+ (MDPPublicGamificationStatusModel *)publicGamificationStatusModelWithIdUser:(NSString *)idUser
                                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPublicGamificationStatusWithDictionary:(NSDictionary *)dictionary
                                                   managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)publicGamificationStatusFetchedResultsControllerWithIdUser:(NSString *)idUser
                                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
