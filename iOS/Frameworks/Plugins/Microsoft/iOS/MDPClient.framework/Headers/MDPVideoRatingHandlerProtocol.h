//
//  MDPVideoRatingHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 18/8/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#ifndef MDPVideoRatingHandlerProtocol_h
#define MDPVideoRatingHandlerProtocol_h


#import "MDPPagedVideoRatingModel.h"
#import "MDPUserVideoRatingModel.h"


#pragma mark - MDPVideoRatingHandlerProtocol
@protocol MDPVideoRatingHandlerProtocol <NSObject>

/*
 Sends to platform the video rating
 */
+ (void)postRateVideoWithVideoId:(NSString *)videoId rating:(NSDecimalNumber *)rating completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets the paginated videos ratings
 */
+ (void)getVideoRatingWithCt:(NSString *)ct completionBlock:(void(^)(MDPPagedVideoRatingModel *content, NSError *error))completionBlock;

/*
 Gets the VideoRating by its id
 */
+ (void)getVideoRatingWithId:(NSString *)videoId completionBlock:(void(^)(MDPUserVideoRatingModel *content, NSError *error))completionBlock;


/*
 FetchedResultsController. Return the UserVideoRating with value VideoId. If videoId is nil, it returns all the objects: UserVideoRating
 */
+ (NSFetchedResultsController *)videoRatingFetchedResultsControllerWithVideoId:(NSString *)videoId delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif /* MDPVideoRatingHandlerProtocol_h */
