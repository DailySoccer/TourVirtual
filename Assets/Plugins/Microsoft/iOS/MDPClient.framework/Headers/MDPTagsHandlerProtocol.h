//
//  MDPTagsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 28/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPTagsHandlerProtocol_h
#define MDPClient_MDPTagsHandlerProtocol_h


#pragma mark - Models
#import "MDPFanTagsModel.h"
#import "MDPTagInfoModel.h"


#pragma mark - Response
typedef void (^MDPTagsHandlerResponseBlock)(NSArray *response, NSError *error);

#pragma mark - MDPTagsHandlerProtocol
@protocol MDPTagsHandlerProtocol <NSObject>

/*
 Gets list of tags to which the current user is subscribed for a client
 */
+ (void)getFanTagsWithCompletionBlock:(MDPTagsHandlerResponseBlock)completionBlock;

/*
 Gets list of tags available in the platform for a client
 */
+ (void)getTagsAvailableByPlatformWithLanguage:(NSString *)language
                               completionBlock:(MDPTagsHandlerResponseBlock)completionBlock;


/*
 Subscribe current user to receive notifications sent to received tag
 */
+ (void)postTagSubscriptionByCurrentUserWithTag:(NSString *)tag
       completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Unsubscribe current user from receive notifications sent to received tag
 */
+ (void)deleteTagSubscriptionByCurrentUserWithTag:(NSString *)tag
                                  completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Subscribe or unsubscribe the current user tags.
 */
+ (void)postUserNotificationTagsWithCollectionUserNotificationTag:(NSArray *)params
                                                  completionBlock:(void(^)(NSError *error))completionBlock;



/*
Listens changes in BD
 */
+ (NSFetchedResultsController *)fanMeTagsFetResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif























































