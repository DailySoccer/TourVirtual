//
//  MDPGroupsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 30/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPGroupsHandlerProtocol_h
#define MDPClient_MDPGroupsHandlerProtocol_h


@import UIKit;

#import "MDPPagedCommentsModel.h"
#import "MDPGroupModel.h"
#import "MDPPagedGroupMembersModel.h"
#import "MDPPagedGroupMembersModel.h"
#import "MDPPagedGroupsModel.h"
#import "MDPPagedIndexedGroupsModel.h"
#import "MDPPagedRequestJoinGroupModel.h"



#pragma mark - Response
typedef void (^MDPGroupsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPGroupsHandlerProtocol
@protocol MDPGroupsHandlerProtocol <NSObject>

/*
 Creates a new group.
 */
+ (void)postNewGroupWithGroupType:(MDPGroupModelGroupType)groupType
                             name:(NSString *)name
                          country:(NSString *)country description:(NSArray *)localeDescription
                  completionBlock:(void(^)(NSString *idGroup, NSError *error))completionBlock;


/*
 Get group for a match
 */
+ (void)getGroupByMatchWithIdSeason:(NSString *)idSeason
                      idCompetition:(NSString *)idCompetition
                            idMatch:(NSString *)idMatch
                           language:(NSString *)language
                    completionBlock:(void(^)(MDPGroupModel *content, NSError *error))completionBlock;

/*
 Get a group by his identifier.
 */
+ (void)getGroupWithIdGroup:(NSString *)idGroup
                   language:(NSString *)language
            completionBlock:(void(^)(MDPGroupModel *content, NSError *error))completionBlock;


/*
 Write a new comment on a group thread.
 */
+ (void)postCommentWithIdGroup:(NSString *)idGroup
                      idThread:(NSString *)idThread
                          text:(NSString *)text
               completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets all comments of a group with the most recent answers if it applies.
 */
+ (void)getGroupCommentsWithIdGroup:(NSString *)idGroup
                           idThread:(NSString *)idThread
                                 ct:(NSString *)ct
                    completionBlock:(void(^)(MDPPagedCommentsModel *content, NSError *error))completionBlock;


/*
 Changes the name of a group
 */
+ (void)putGroupNameWithIdGroup:(NSString *)idGroup
                           text:(NSString *)text
                completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Get a paginated list of the members of a group
 */
+ (void)getGroupMembersWithIdGroup:(NSString *)idGroup
                                ct:(NSString *)ct
                   completionBlock:(void (^)(MDPPagedGroupMembersModel *content, NSError *error))completionBlock;


/*
 Invite an user to join to a group.
 */
+ (void)postInviteUserWithIdGroup:(NSString *)idGroup
                           idUser:(NSString *)idUser
                  completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Delete an user from a group
 */
+ (void)leaveGroupWithIdGroup:(NSString *)idGroup
              completionBlock:(void(^)(NSError *error))completionBlock;



/*
 Get a paginated list of the logged fan groups
 */
+ (void)putAvatarWithIdGroup:(NSString *)idGroup
                       image:(UIImage *)image
             completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Get a paginated list of the logged fan groups
 */
+ (void)getFanGroupsWithCt:(NSString *)ct
                  language:(NSString *)language
           completionBlock:(void (^)(MDPPagedGroupsModel *content, NSError *error))completionBlock;

/*
 Gets a paginated list of community groups.
 */
+ (void)getCommunityGroupsWithPageNumber:(NSInteger)pageNumber
                               groupName:(NSString *)groupName
                         completionBlock:(void (^)(MDPPagedIndexedGroupsModel *content, NSError *error))completionBlock;

/*
 Creates a request to join a group.
 */
+ (void)requestJoinGroupWithIdGroup:(NSString *)idGroup
                    completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Converts a group member into a group administrator.
 */
+ (void)convertGroupMemberToGroupAdminWithIdGroup:(NSString *)idGroup
                                           idUser:(NSString *)idUser
                                            alias:(NSString *)alias
                                          isAdmin:(BOOL)isAdmin
                                  completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets a list of pending requests for joining to group.
 */
+ (void)getPendingRequestsForJoiningGroupWithIdGroup:(NSString *)idGroup
                                                  ct:(NSString *)ct
                                     completionBlock:(void (^)(MDPPagedRequestJoinGroupModel *content, NSError *error))completionBlock;

/*
 Rejects a request for joining a group.
 */
+ (void)rejectRequestForJoiningGroupWithIdGroup:(NSString *)idGroup
                                      idRequest:(NSString *)idRequest
                                completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Accepts a request for joining a group.
 */
+ (void)acceptRequestForJoiningGroupWithIdGroup:(NSString *)idGroup
                                      idRequest:(NSString *)idRequest
                                completionBlock:(void(^)(NSError *error))completionBlock;

@end

#endif /* MDPGroupsHandlerProtocol_h */













































