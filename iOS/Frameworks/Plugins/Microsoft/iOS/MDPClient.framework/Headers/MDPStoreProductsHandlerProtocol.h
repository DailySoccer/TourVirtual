//
//  MDPStoreProductsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 4/12/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPStoreProductsHandlerProtocol_h
#define MDPClient_MDPStoreProductsHandlerProtocol_h

#import "MDPStoreProductModel.h"
#import "MDPProductItemModel.h"
#import "MDPPagedStoreProductsModel.h"


#pragma mark - MDPStoreProductsHandlerProtocol
@protocol MDPStoreProductsHandlerProtocol <NSObject>

/*
 Gets a store product.
 */
+ (void)getStoreProductWithIdProduct:(NSString *)idProduct
                           language:(NSString *)language
                    completionBlock:(void(^)(MDPStoreProductModel *content, NSError *error))completionBlock;


/*
 Gets a paged collection of store products.
 */
+ (void)getStoreProductsByClientIdWithLanguage:(NSString *)language
                                            ct:(NSString *)ct
                               completionBlock:(void(^)(MDPPagedStoreProductsModel *content, NSError *error))completionBlock;

@end


#endif /* MDPStoreProductsHandlerProtocol_h */
