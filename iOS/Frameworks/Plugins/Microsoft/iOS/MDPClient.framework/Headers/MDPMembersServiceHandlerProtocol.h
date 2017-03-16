//
//  MDPMembersServiceHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 6/9/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import "MDPMemberCardInfoModel.h"
#import "MDPMemberAccessPassModel.h"
#import "MDPLinkedMemberInfoModel.h"


@import UIKit;


#pragma mark StatusTypes
typedef NS_ENUM(NSUInteger, MDPServiceResponseMemberSeatSaleStatusType) {
    
    MDPServiceResponseMemberSeatSaleStatusTypeError                 = -1,
    MDPServiceResponseMemberSeatSaleStatusTypeSuccess               = 0,
    MDPServiceResponseMemberSeatSaleStatusTypeNoSeat                = 1,
    MDPServiceResponseMemberSeatSaleStatusTypeCedeNotAllowed        = 2,
    MDPServiceResponseMemberSeatSaleStatusTypeStartedGame           = 3,
    MDPServiceResponseMemberSeatSaleStatusTypeGameIsNotAvailable    = 4,
    MDPServiceResponseMemberSeatSaleStatusTypeGameDoesntExist       = 5,
    MDPServiceResponseMemberSeatSaleStatusTypeSeatHasBeenCeded      = 6,
    MDPServiceResponseMemberSeatSaleStatusTypeSeatIsNotRecoverable  = 7,
    MDPServiceResponseMemberSeatSaleStatusTypeIssuedSeat            = 8,
};

typedef NS_ENUM(NSUInteger, MDPServiceResponseMemberSeatRecoverStatusType) {

MDPServiceResponseMemberSeatRecoverStatusTypeError                       = -1,
MDPServiceResponseMemberSeatRecoverStatusTypeSuccess                     = 0,
MDPServiceResponseMemberSeatRecoverStatusTypeNoSeat                      = 1,
MDPServiceResponseMemberSeatRecoverStatusTypeStartedGame                 = 2,
MDPServiceResponseMemberSeatRecoverStatusTypeGameIsNotAvailable          = 3,
MDPServiceResponseMemberSeatRecoverStatusTypeGameDoesntExist             = 4,
MDPServiceResponseMemberSeatRecoverStatusTypeSeatIsNotRecoverable        = 5,
MDPServiceResponseMemberSeatRecoverStatusTypeIssuedSeat                  = 6,
};


#pragma mark - Response
typedef void (^MDPMembersServiceHandlerResponseBlock)(NSArray *response, NSError *error);


#ifndef MDPMembersServiceHandlerProtocol_h
#define MDPMembersServiceHandlerProtocol_h


@protocol MDPMembersServiceHandlerProtocol <NSObject>

/*
 Links the member identity with the DP identity
 */
+ (void)putLinkMemberWithMemberNumber:(NSUInteger)memberNumber PIN:(NSString *)pin completionBlock:(void(^)(MDPLinkedMemberInfoModel *content, NSError *error))completionBlock;

/*
 Generates a token for SSO access mode in the OAS from the official App
 */
+ (void)postAcquireTokenWithPIN:(NSString *)pin completionBlock:(void(^)(NSString *content, NSError *error))completionBlock;

/*
 Gets the member card information with his picture
 */
+ (void)getMemberCardInfoWithPIN:(NSString *)pin completionBlock:(void(^)(MDPMemberCardInfoModel *content, NSError *error))completionBlock;

/*
 Gets the member venue info by sport type.
 */
+ (void)getMemberSeatInfoWithPIN:(NSString *)pin completionBlock:(MDPMembersServiceHandlerResponseBlock)completionBlock;

/*
 Gets a collection of matches of the current season with the information regarding of the cession seat for the current match.
 */
+ (void)getMemberMatchesInfoWithPIN:(NSString *)pin language:(NSString *)language completionBlock:(MDPMembersServiceHandlerResponseBlock)completionBlock;

/*
 Allows to a member cede their seat for a specific match of the main team.
 */
+ (void)putSellMemberSeatWithPIN:(NSString *)pin idMatchAvet:(NSString *)idMatchAvet completionBlock:(void(^)(MDPServiceResponseMemberSeatSaleStatusType statusType, NSError *error))completionBlock;

/*
 Allows to a member recover their ceded seat for a specific match of the main team before it has been sold.
 */
+ (void)putRecoverMemberSeatWithPIN:(NSString *)pin idMatchAvet:(NSString *)idMatchAvet completionBlock:(void(^)(MDPServiceResponseMemberSeatRecoverStatusType statusType, NSError *error))completionBlock;

/*
 Gets a QR code that allows member to enter the stadium
 */
+ (void)getMemberAccessPassWithPIN:(NSString *)pin completionBlock:(void(^)(MDPMemberAccessPassModel *content, NSError *error))completionBlock;

/*
 Puts a new photo for a member. The image is loaded from request's body
 */
+ (void)putUploadMemberAvatarWithImage:(UIImage *)image PIN:(NSString *)pin completionBlock:(void (^)(NSError *error))completionBlock;

@end

#endif /* MDPMembersServiceHandlerProtocol_h */











































































