//
//  MDPUserActionHistoryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPUserActionHistoryModel.h"


#pragma mark - Interface
@interface MDPUserActionHistoryModel : _MDPUserActionHistoryModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)userActionHistoryFetchedResultsControllerWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSArray *)userActionsHistoryWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

@end
