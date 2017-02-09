//
//  MDPPurchasesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 16/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPPurchasesHandlerProtocol_h
#define MDPClient_MDPPurchasesHandlerProtocol_h


#pragma mark - MDPPurchasesHandlerProtocol
@protocol MDPPurchasesHandlerProtocol <NSObject>

/*
 After an user buy some product through the store, this action must be call to register points.
 */
+ (void)postPurchaseWithIdProduct:(NSString *)idProduct
                          receipt:(NSString *)receipt
                  useVirtualGoods:(BOOL)useVirtualGoods
                  completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Allows a user to redeem virtual goods.
 */
+ (void)postRedeemVirtualGoodsWithArrayIdVirtualGoods:(NSArray *)arrayIdVirtualGood
                                    completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Allows a user to redeem subscriptions.
 */
+ (void)postRedeemSubscriptionWithIdsubscription:(NSString *)idSubscription
                                  completionBlock:(void(^)(NSError *error))completionBlock;

@end

#endif 



































































































