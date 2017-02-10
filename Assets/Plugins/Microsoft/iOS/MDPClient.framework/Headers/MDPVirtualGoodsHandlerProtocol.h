//
//  MDPVirtualGoodsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 23/2/15.
//  Copyright (c) 2015 Luis Paez Gonzalez. All rights reserved.
//

#ifndef MDPClient_MDPVirtualGoodsHandlerProtocol_h
#define MDPClient_MDPVirtualGoodsHandlerProtocol_h

#import "MDPPagedVirtualGoodModel.h"
#import "MDPPagedVirtualGoodTypeModel.h"
#import "MDPVirtualGoodTypeModel.h"

#pragma mark - Response
typedef void (^MDPVirtualGoodsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPVirtualGoodsHandlerProtocol
@protocol MDPVirtualGoodsHandlerProtocol <NSObject>

/*
 Gets available virtual goods for a type.
 */
+ (void)getVirtualGoodsByTypeWithIdType:(NSString *)idType
                                     ct:(uint)ct
                               language:(NSString *)language
                              idSubType:(NSString *)idSubType
                       onlyPurchasables:(BOOL)onlyPurchasables
                        completionBlock:(void(^)(MDPPagedVirtualGoodModel *content, NSError *error))completionBlock;

/*
Gets the paginated list of availables virtual good types.
 */
+ (void)getVirtualGoodTypesWithCt:(uint)ct
                         language:(NSString *)language
                             type:(NSString *)type
                  completionBlock:(void (^)(MDPPagedVirtualGoodTypeModel *content, NSError *error))completionBlock;

/*
 Gets a virtual good type by his id.
 */
+ (void)getVirtualGoodsTypeByIdWithIdType:(NSString *)idType
                                 language:(NSString *)language
                          completionBlock:(void(^)(MDPVirtualGoodTypeModel *content, NSError *error))completionBlock;


/*
 Gets available highlight virtual goods for a type.
 */
+ (void)getVirtualGoodsHighLightByTypeWithCt:(uint)ct
                                      idType:(NSString *)idType
                                   idSubType:(NSString *)idSubType
                                    language:(NSString *)language
                            onlyPurchasables:(BOOL)onlyPurchasables
                             completionBlock:(void(^)(MDPPagedVirtualGoodModel *content, NSError *error))completionBlock;

/*
 Gets a specific virtual good.
 */
+ (void)getVirtualGoodByIdWithIdVirtualGood:(NSString *)idVirtualGood
                                purchasable:(BOOL)purchasable
                            completionBlock:(void(^)(MDPVirtualGoodModel *content, NSError *error))completionBlock;


/*
 Listens to MDPVirtualGoods objects
 */
+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  purchasable:(BOOL)purchasable
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  isHighLight:(BOOL)isHighLight
                                                         isHighLighInCategory:(BOOL)isHighLightInCategory
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithIdType:(NSString *)idType
                                                                  onlyParents:(BOOL)onlyParents
                                                                    idSubType:(NSString *)idSbubType
                                                                  isHighLight:(BOOL)isHighLight
                                                         isHighLighInCategory:(BOOL)isHighLightInCategory
                                                                  purchasable:(BOOL)purchasable
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithId:(NSString *)idVirtualGood
                                                                 delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodFetchedResultsControllerWithPurchasable:(BOOL)purchasable
                                                                     delegate:(id <NSFetchedResultsControllerDelegate>)delegate;



/*
 Listens to MDPVirtualGoodTypeModel objects
 */
+ (NSFetchedResultsController *)parentVirtualGoodTypeFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodTypeFetchedResultsControllerWithParentIdType:(NSString *)parentIdType
                                                                               delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Listens to MDPPagedVirtualGoodModel objects
 */
+ (NSFetchedResultsController *)pagedVirtualGoodFetchedResultsControllerWithTypeId:(NSString *)idType
                                                                                ct:(NSNumber *)ct
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)pagedVirtualGoodFetchedResultsControllerWithTypeId:(NSString *)idType
                                                                                ct:(NSNumber *)ct
                                                                       isHighLight:(BOOL)isHighLight
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Listens to MDPVirtualGoodType
 */
+ (NSFetchedResultsController *)pagedVirtualGoodTypeFetchedResultsControllerWithCt:(NSNumber *)ct
                                                                              type:(NSString *)type
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif














































































