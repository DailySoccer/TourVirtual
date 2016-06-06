//
//  MDPNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPNotificationModel.h"


#pragma mark - Interface
@interface MDPNotificationModel : _MDPNotificationModel

+ (instancetype)notificationWithIdNotification:(NSString *)idNotification managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsNotificationWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)fanNotificationsFetchedResultsControllerManagedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
