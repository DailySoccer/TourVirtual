//
//  MDPPagedVirtualGoodModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPagedVirtualGoodModel.h"


#pragma mark - Interface
@interface MDPPagedVirtualGoodModel : _MDPPagedVirtualGoodModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary onlyPurchasables:(BOOL)onlyPurchasables managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)pagedVirtualGoodFetchedResultsControllerWithTypeId:(NSString *)idType
                                                                                ct:(NSNumber *)ct
                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)pagedVirtualGoodFetchedResultsControllerWithTypeId:(NSString *)idType
                                                                                ct:(NSNumber *)ct
                                                                       isHighLight:(BOOL)isHighLight
                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
