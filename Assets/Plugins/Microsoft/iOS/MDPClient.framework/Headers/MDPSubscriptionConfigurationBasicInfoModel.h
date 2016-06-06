//
//  MDPSubscriptionConfigurationBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionConfigurationBasicInfoModel.h"


#pragma mark - Interface
@interface MDPSubscriptionConfigurationBasicInfoModel : _MDPSubscriptionConfigurationBasicInfoModel

+ (instancetype)subscriptionConfigurationBasicInfoWithIdSubscription:(NSString *)idSubscription managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSubscriptionConfigurationBasicInfoWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithIdSubscription:(NSString *)idSubscription
                                                                                        managedObjectContext:(NSManagedObjectContext *)context
                                                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithHighLight:(BOOL)highLight
                                                                                    highLightInCategory:(BOOL)highLightInCategory
                                                                                   managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                                         highLight:(BOOL)highLight
                                                                               highLightInCategory:(BOOL)highLightInCategory
                                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
