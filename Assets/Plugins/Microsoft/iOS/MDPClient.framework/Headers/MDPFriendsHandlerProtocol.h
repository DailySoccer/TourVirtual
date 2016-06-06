//
//  MDPFriendsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 17/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPFriendsHandlerProtocol_h
#define MDPClient_MDPFriendsHandlerProtocol_h

#pragma mark - Response
typedef void (^MDPFriendsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark Sport Type
typedef NS_ENUM(NSInteger, MDPFriendsGiftType) {
    MDPFriendsGiftTypeVirtualGood   = 1
} ; 


#pragma mark - MDPFriendsHandlerProtocol
@protocol MDPFriendsHandlerProtocol <NSObject>

/*
 Get fan friends.
 */
+ (void)getFriendsWithCompletionBlock:(MDPFriendsHandlerResponseBlock)completionBlock;

/*
 Send a new frienship invitation
 */
+ (void)postFriendWithIdUserFriend:(NSString *)idUserFriend
                   completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Delete a friendship
 */
+ (void)deleteFriendshipWithIdUserFriend:(NSString *)idUserFriend
                         completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets the list of the user's invitations.
 */
+ (void)getInvitationsWithCompletionBlock:(MDPFriendsHandlerResponseBlock)completionBlock;

/*
Invite a contact to the platform through his email.
 */
+ (void)postPlatformInvitationWithEmail:(NSString *)email completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Send a gift to a friend.
 */
+ (void)postGiftWithIdReceiverUser:(NSString *)idReceiverUser
                              type:(MDPFriendsGiftType)type
                     idVirtualGood:(NSString *)idVirtualGood
                   completionBlock:(void(^)(NSError *error))completionBlock;

@end

#endif



















































