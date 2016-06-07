//
//  MDPPaidFansHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 3/6/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#ifndef MDPPaidFansHandlerProtocol_h
#define MDPPaidFansHandlerProtocol_h

#import "MDPPaidFanLinkedStatusModel.h"


#pragma mark  - PaidFanEmailConfirmationType
typedef NS_ENUM(NSInteger, MDPPaidFanEmailConfirmationType) {
    MDPPaidFanEmailConfirmationTypeLogin                    = 0,
    MDPPaidFanEmailConfirmationTypePaidFan                  = 1,
};


#pragma mark - MDPPaidFansHandlerProtocol
@protocol MDPPaidFansHandlerProtocol <NSObject>

/*
 Link user profile with his Madridista account.
 */
+ (void)putLinkPaidFanProfileWithPaidFannumber:(NSString *)paidFanNumber
                                      password:(NSString *)password
                               completionBlock:(void(^)(MDPPaidFanLinkedStatusModel *content, NSError *error))completionBlock;

/*
 Confirm user account email, between paid fan or DP email.
 */
+ (void)putPaidFanEmailWithEmail:(NSString *)email
                   paidFanNumber:(NSString *)paidFanNumber
                        password:(NSString *)password
                     emailSource:(MDPPaidFanEmailConfirmationType)emailSource
                 completionBlock:(void(^)(NSError *error))completionBlock;

@end

#endif /* MDPPaidFansHandlerProtocol_h */
