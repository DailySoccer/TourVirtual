//  MDPMenuModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMenuModel.h"

#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPMenuModelSportType) {
    MDPMenuModelSportTypeFootball  = 1,
    MDPMenuModelSportTypeBasket    = 2,
};


#pragma mark - MatchStatusType
typedef NS_ENUM(NSInteger, MDPMenuModelMatchStatusType) {
    MDPMenuModelMatchStatusTypeNonGameDay    = 0,
    MDPMenuModelMatchStatusTypeGameDay       = 1,
    MDPMenuModelMatchStatusTypePreGame       = 2,
    MDPMenuModelMatchStatusTypeDuringGame    = 3,
    MDPMenuModelMatchStatusTypePostGame      = 4,
};


#pragma mark - Parameters
extern const struct MDPMenuModelParameters {
    __unsafe_unretained NSString *keyLayout;
    __unsafe_unretained NSString *valueLayoutTypeLandscape;
}MDPMenuModelParameters;


#pragma mark - Interface
@interface MDPMenuModel : _MDPMenuModel

+ (NSArray *)menuItemsWithAppId:(NSString *)appId
                        country:(NSString *)country
                       language:(NSString *)language
                       sporType:(int)sporType
           managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsMenuWithDictionary:(NSDictionary *)dictionary sportType:(MDPMenuModelSportType)sportType managedObjectContext:(NSManagedObjectContext *)context;


#pragma mark - Fetchs
+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId
                                                                   country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                                    filter:(NSString *)filter
                                                               emptyFilter:(BOOL)emptyFilter
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId
                                                                   country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                                   idLevel:(NSNumber *)idLevel
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId
                                                                   country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                                   idLevel:(NSNumber *)idLevel
                                                                    filter:(NSString *)filter
                                                               emptyFilter:(BOOL)emptyFilter
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId
                                                                   country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                                   idLevel:(NSNumber *)idLevel
                                                                  idParent:(NSString *)idParent
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsFetchedResultsControllerWithAppId:(NSString *)appId
                                                                   country:(NSString *)country
                                                                     sport:(MDPMenuModelSportType)sportType
                                                                  language:(NSString *)language
                                                                   idLevel:(NSNumber *)idLevel
                                                                  idParent:(NSString *)idParent
                                                                    filter:(NSString *)filter
                                                               emptyFilter:(BOOL)emptyFilter
                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

- (NSDictionary *)parametersDictionary;


#pragma mark - This method gets the Advertisement
+ (NSArray *)advertisementsIn:(NSArray *)menuItems forMenuWithMenuItemId:(NSString *)menuItemId position:(NSString *)position;

@end