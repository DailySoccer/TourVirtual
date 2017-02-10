//
//  MDPPlatformNotificationsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 10/6/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPPlatformNotificationsHandlerProtocol_h
#define MDPClient_MDPPlatformNotificationsHandlerProtocol_h

#import "MDPPagedPlatformNotificationsModel.h"


#pragma mark - MDPPlatformNotificationsHandlerProtocol
@protocol MDPPlatformNotificationsHandlerProtocol <NSObject>

/*
 Gets the current client platform notifications.
 */
+ (void)getPlatformNotificationsByClientWithContinuationToken:(NSString *)continuationToken
                                            language:(NSString *)language
                                     completionBlock:(void(^)(MDPPagedPlatformNotificationsModel *content, NSError *error))completionBlock;

/*
 Gets the current client platform notifications.
 */
+ (void)getPlatformNotificacionByCliendAndIdWithIdNotification:(NSString *)idNotification
                                                language:(NSString *)language
                                         completionBlock:(void(^)(MDPPlatformNotificationModel *content, NSError *error))completionBlock;

/*
 Fetch controller
 */
+ (NSFetchedResultsController *)platformNotificationsFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif
