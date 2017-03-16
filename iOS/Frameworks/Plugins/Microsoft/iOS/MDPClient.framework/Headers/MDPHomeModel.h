//
//  MDPHomeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPHomeModel.h"


#pragma mark - MDPHomeModelIdService
extern const struct MDPHomeModelIdService{
    __unsafe_unretained NSString *videoSingle;
    __unsafe_unretained NSString *videoMultiple;
    __unsafe_unretained NSString *nextGames;
    __unsafe_unretained NSString *advertisement;
    __unsafe_unretained NSString *classificationAndFixtures;
    __unsafe_unretained NSString *newsMultiple;
    __unsafe_unretained NSString *missedMatch;
    __unsafe_unretained NSString *matchDay;
    __unsafe_unretained NSString *promotion;
    __unsafe_unretained NSString *listGenericContent;
    __unsafe_unretained NSString *adMultiple;
    __unsafe_unretained NSString *social;
    __unsafe_unretained NSString *customButtons;
    __unsafe_unretained NSString *purchase_virtualgood;
    __unsafe_unretained NSString *subscription_single;
    __unsafe_unretained NSString *subscription_purchaseable;
}MDPHomeModelIdService;

#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPHomeModelSportType) {
    MDPHomeModelSportTypeFootball  = 1,
    MDPHomeModelSportTypeBasket    = 2,
};

#pragma mark - Segmented Selector Component Type
typedef NS_ENUM(NSInteger, MDPHomeModelSegmentedSelectorComponentType) {
    MDPHomeModelSegmentedSelectorComponentTypeClassification = 0,
    MDPHomeModelSegmentedSelectorComponentTypeFixtures = 1,
    MDPHomeModelSegmentedSelectorComponentTypeMatchFinder = 2
};


#pragma mark - Interface
@interface MDPHomeModel : _MDPHomeModel

+ (NSArray *)startItemsWithAppId:(NSString *)appId country:(NSString *)country managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsHomeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)startItemsFetchedResultsControllerWithAppId:(id)appId
                                                                    country:(NSString *)country
                                                                  sportType:(int)sportType
                                                                     column:(NSNumber *)column
                                                       managedObjectContext:(NSManagedObjectContext *)context
                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

- (NSNumber *)nextMatchNumberOfMatches;

- (NSArray *)nextMatchItems;

- (NSNumber *)previousMatchNumberOfMatches;

- (NSArray *)previousMatchItems;

- (NSString *)videoIdContentLanguage:(NSString *)language;

- (NSString *)backgroundUrl;

- (NSString *)sponsorBannerUrl;

- (NSString *)backgroundImagePromotionUrl;

- (NSString *)contentType;

- (NSArray *)classificationAndFixturesEnabledValues;

- (NSString *)genericControlBackgroundImageUrlForLanguage:(NSString *)language;

- (NSString *)genericControlContentTypeForLanguage:(NSString *)language;

- (NSString *)genericControlNavigationTypeForLanguage:(NSString *)language;

- (NSArray *)multipleAdvertisementItems;

- (NSArray *)arrayIdSubscriptionForLanguage:(NSString *)language;

// Subscription Placeholder
- (NSString *)availabilityDateTime;

- (NSString *)imageNotPurchasedForLanguage:(NSString *)language;

- (NSString *)imagePurchasedForLanguage:(NSString *)language;

- (NSString *)urlRedirectUserNotPurchasedForLanguage:(NSString *)language;

- (NSString *)urlRedirectUserPurchasedForLanguage:(NSString *)language;

- (NSString *)idSubscription;

@end
