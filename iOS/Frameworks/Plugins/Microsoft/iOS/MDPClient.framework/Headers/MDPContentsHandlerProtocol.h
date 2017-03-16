//
//  MDPContentsHandlerProtocol.h
//  MDPClient
//
//  Created by Javier Ovejero on 16/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPContentsHandlerProtocol_h
#define MDPClient_MDPContentsHandlerProtocol_h

#pragma mark - Model
#import "MDPContentModel.h"
#import "MDPContentParagraphModel.h"
#import "MDPAssetModel.h"
#import "MDPContentLinkModel.h"
#import "MDPPagedCompactContentModel.h"
#import "MDPCompactContentModel.h"
#import "MDPVideoAdInformationModel.h"
#import "MDPFavoriteModel.h"
#import "MDPPagedFavoriteContentModel.h"


#pragma mark VideoAdType
typedef NS_ENUM(NSUInteger, MDPContentVideoAdType) {
    MDPContentVideoAdTypePreroll    =   0,
    MDPContentVideoAdTypePostroll   = 1,
};


#pragma mark
typedef NS_ENUM(NSUInteger, MDPContentAssetVideoType) {
    MDPContentAssetVideoTypeProgressive         = 0,
    MDPContentAssetVideoTypeHDS                 = 1,
    MDPContentAssetVideoTypeHLS                 = 2,
    MDPContentAssetVideoTypeSmoothStreaming     = 3,
};

// #pragma mark - Response
 typedef void (^MDPContentsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPContentsHandlerProtocol
@protocol MDPContentsHandlerProtocol <NSObject>

/*
 Gets a content item identified by id content
 */
+ (void)getContentItemWithIdContent:(NSString *)idContent
                    completionBlock:(void(^)(MDPContentModel *content, NSError *error))completionBlock;


/*
 Gets a list of content items of a specific type in a status published
 */
+ (void)getContentItemsByTypeWithUseCache:(BOOL)useCache
                                     type:(MDPContentModelContentType)type
                          alternativeType:(NSString *)alternativeType
                                 language:(NSString *)language
                                       ct:(uint)ct
                          completionBlock:(void(^)(MDPPagedCompactContentModel *contentResults, NSError *error))completionBlock;

/*
 Gets a list of highlight content items of a specific type in status published
 */
+ (void)getHighlightContentItemsByTypeWithUseCache:(BOOL)useCache
                                              type:(MDPContentModelContentType)type
                                          language:(NSString *)language
                                                ct:(int)ct
                                   completionBlock:(void(^)(MDPPagedCompactContentModel *contentResults, NSError *error))completionBlock;

/*
 Gets the paginated list of related news of a content.
*/
+ (void)getRelatedContentWithIdContent:(NSString *)idContent
                                    ct:(int)ct
                       completionBlock:(void(^)(MDPPagedCompactContentModel *contentResults, NSError *error))completionBlock;


/*
 Gets for a specific content type and country its related advertisement
 */
+ (void)getVideoAdWithType:(NSString *)type
                      country:(NSString *)country
                  videoAdType:(MDPContentVideoAdType)videoAdType
                    videoType:(MDPContentAssetVideoType)videoType
              completionBlock:(void(^)(MDPVideoAdInformationModel *xml, NSError *error))completionBlock;

/*
 Add content as part of user's favorite content
 */
+ (void)postFavoriteContentWithIdContent:(NSString *)idContent
                         completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Remove content as part of user's favorite content
 */
+ (void)deleteFavoriteContentWithIdContent:(NSString *)idContent
                           completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets the list of paginated user's favorite content items
 */
+ (void)getPagedFavoriteContentWithPageSize:(NSNumber *)pageSize
                                         ct:(NSString *)ct
                            completionBlock:(void(^)(MDPPagedFavoriteContentModel *content, NSError *error))completionBlock;

/*
 Gets for a specific content type and country its related advertisements in VMAP format
 */
+ (void)getVideoVmapWithType:(NSString *)type
                     country:(NSString *)country
                 videoAdType:(NSUInteger)videoAdType
                   videoType:(NSUInteger)videoType
             completionBlock:(void(^)(NSString *url, NSString *xml, NSError *error))completionBlock;

/*
 Get user's favorite content by identifier
 */
+ (void)getFavoriteContentWithIdContent:(NSString *)idContent
                        completionBlock:(void(^)(MDPFavoriteModel *content, NSError *error))completionBlock;


#pragma mark - Gets Content
+ (MDPContentModel *)contentWithIdContent:(NSString *)idContent;

+ (void)deleteAllFavoriteContents;

+ (NSFetchedResultsController *)favoriteNewsFetchedResultsControllerWithFilters:(NSArray *)filters delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)favoriteVideosFetchedResultsControllerWithFilters:(NSArray *)filters delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif




























































































