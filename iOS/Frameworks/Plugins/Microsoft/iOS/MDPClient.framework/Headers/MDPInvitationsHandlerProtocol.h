//
//  MDPInvitationsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 24/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPInvitationsHandlerProtocol_h
#define MDPClient_MDPInvitationsHandlerProtocol_h

@protocol MDPInvitationsHandlerProtocol <NSObject>

/*
 Answer to an invitation.
 */
+ (void)putInvitationWithIdInvitation:(NSString *)idInvitation answer:(BOOL)answer completionBlock:(void(^)(NSError *error))completionBlock;

@end


#endif /* MDPInvitationsHandlerProtocol_h */
