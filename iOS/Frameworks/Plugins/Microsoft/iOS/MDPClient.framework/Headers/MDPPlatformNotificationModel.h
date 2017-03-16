//
//  MDPPlatformNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlatformNotificationModel.h"


#pragma mark - Interface
@interface MDPPlatformNotificationModel : _MDPPlatformNotificationModel

+ (instancetype)insertIfNotExistsPlatformNotificationWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)platformNotificationWithIdClient:(NSString *)idClient
                                  idNotification:(NSString *)idNotification
                            managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)platformNotificationsFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                             delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
