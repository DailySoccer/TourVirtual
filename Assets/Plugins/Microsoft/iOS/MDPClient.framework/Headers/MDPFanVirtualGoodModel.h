//
//  MDPFanVirtualGoodModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanVirtualGoodModel.h"


#pragma mark - Interface
@interface MDPFanVirtualGoodModel : _MDPFanVirtualGoodModel

+ (MDPFanVirtualGoodModel *)fanVirtualGoodWithId:(NSString *)idVirtualGood
                                        language:(NSString *)language
                            managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanVirtualGoodWithDictionary:(NSDictionary *)dictionary
                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanVirtualGoodWithDictionary:(NSDictionary *)dictionary
                                                     language:(NSString *)language
                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)fanVirtualGoodFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                      delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)fanVirtualGoodFetchedResultsControllerWithId:(NSString *)idVirtualGood
                                                                      typeId:(NSString *)idType
                                                        managedObjectContext:(NSManagedObjectContext *)context
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
