//
//  MDPVirtualGoodModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVirtualGoodModel.h"


#pragma mark - Interface
@interface MDPVirtualGoodModel : _MDPVirtualGoodModel

+ (MDPVirtualGoodModel *)virtualGoodWithIdVirtualGood:(NSString *)idVirtualGood
                                          purchasable:(BOOL)purchasable
                                 managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsVirtualGoodWithDictionary:(NSDictionary *)dictionary
                                               purchasable:(BOOL)purchasable
                                      managedObjectContext:(NSManagedObjectContext *)context;


/*
  Gets the virtualGoods of a category or the virtualGoods of a subcategory
 */
+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                         managedObjectContext:(NSManagedObjectContext *)context
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  purchasable:(BOOL)purchasable
                                                         managedObjectContext:(NSManagedObjectContext *)context
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  isHighLight:(BOOL)isHighLight
                                                         isHighLighInCategory:(BOOL)isHighLightInCategory
                                                         managedObjectContext:(NSManagedObjectContext *)context
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  isHighLight:(BOOL)isHighLight
                                                         isHighLighInCategory:(BOOL)isHighLightInCategory
                                                                  purchasable:(BOOL)purchasable
                                                         managedObjectContext:(NSManagedObjectContext *)context
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

// Gets a VirtualGood by his id
+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithId:(NSString *)idVirtualGood
                                                     managedObjectContext:(NSManagedObjectContext *)context
                                                                 delegate:(id <NSFetchedResultsControllerDelegate>)delegate;


// Get all the VirtualGoods
+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithPurchasable:(BOOL)purchasable
                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
