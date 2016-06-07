//
//  MDPNotificationsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 28/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPNotificationsHandlerProtocol_h
#define MDPClient_MDPNotificationsHandlerProtocol_h

#import "MDPPagedNotificationsModel.h"
#import "MDPNotificationModel.h"


#pragma mark - MDPNotificationsHandlerProtocol
@protocol MDPNotificationsHandlerProtocol <NSObject>

/*
 Get all notifications available
 */
+ (void)getNotificationsWithCt:(NSString *)ct
               completionBlock:(void(^)(MDPPagedNotificationsModel *content, NSError *error))completionBlock;

/*
 Updates a notifications to readed status.
 */
+ (void)putNotificationWithIdNotification:(NSString *)idNotification
                          completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Deletes a notifications identied by idNotification
 */
+ (void)deleteNotificationWithIdNotification:(NSString *)idNotification
                             completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets a notification from current user by its identifier
 */
+ (void)getNotificationWithIdNotification:(NSString *)idNotification
                          completionBlock:(void(^)(MDPNotificationModel *content, NSError *error))completionBlock;

/*
 Fetch controller
 */
+ (NSFetchedResultsController *)fanNotificationsFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif
