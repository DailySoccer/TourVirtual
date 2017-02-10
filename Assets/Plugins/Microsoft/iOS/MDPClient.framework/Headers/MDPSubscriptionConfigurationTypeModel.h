//
//  MDPSubscriptionConfigurationTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionConfigurationTypeModel.h"


#pragma mark - Interface
@interface MDPSubscriptionConfigurationTypeModel : _MDPSubscriptionConfigurationTypeModel

+ (MDPSubscriptionConfigurationTypeModel *)subscriptionConfigurationTypeWithType:(NSString *)type
                                                                        language:(NSString *)language
                                                            managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSubscriptionTypeWithLanguage:(NSString *)language
                                                   dictionary:(NSDictionary *)dictionary
                                           managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)subscriptionConfigurationTypeFetchedResultsControllerWithLanguage:language
                                                                             managedObjectContext:(NSManagedObjectContext *)context
                                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationTypeFetchedResultsControllerWithLanguage:language
                                                                                        highLight:(BOOL)highLight
                                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
