//
//  MDPAppsHandlerProtocol.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 21/01/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPAppsHandlerProtocol_h
#define MDPClient_MDPAppsHandlerProtocol_h

#include "MDPMenuModel.h"

#pragma mark - Response
typedef void (^MDPAppsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPAppsHandlerProtocol
@protocol MDPAppsHandlerProtocol <NSObject>

/*
 Gets the menu for a trusted client app.
 */
+ (void)getMenuItemsWithCountry:(NSString *)country
                          sport:(MDPMenuModelSportType)sportType
                       language:(NSString *)language
                completionBlock:(MDPAppsHandlerResponseBlock)completionBlock;

/*
 Gets the start screens for a trusted client app.
 */
+ (void)getStartItemsWithCountry:(NSString *)country
                 completionBlock:(MDPAppsHandlerResponseBlock)completionBlock;

/*
 Gets the splash screens for a trusted client app.
 */
+ (void)getSplashItemsWithCountry:(NSString *)country
                  completionBlock:(MDPAppsHandlerResponseBlock)completionBlock;

/*
 Gets the Gamification levels for an app
 */
+ (void)getGamificationLevelsWithLanguage:(NSString *)language
                          completionBlock:(MDPAppsHandlerResponseBlock)completionBlock;


/*
 Listens to MDPHomeModel objects
 */
+ (NSFetchedResultsController *)startItemsFetchedResultsControllerWithCountry:(NSString *)country
                                                                  sportType:(int)sportType
                                                                     column:(NSNumber *)column
                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/**
 Listens to MDPMenuModel objects
 */
+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                              filter:(NSString *)filter
                                         emptyFilter:(BOOL)emptyFilter
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                             idLevel:(NSNumber *)idLevel
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                             idLevel:(NSNumber *)idLevel
                                              filter:(NSString *)filter
                                         emptyFilter:(BOOL)emptyFilter
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                             idLevel:(NSNumber *)idLevel
                                            idParent:(NSString *)idParent
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)menuItemsWithCountry:(NSString *)country
                                               sport:(MDPMenuModelSportType)sportType
                                            language:(NSString *)language
                                             idLevel:(NSNumber *)idLevel
                                            idParent:(NSString *)idParent
                                              filter:(NSString *)filter
                                         emptyFilter:(BOOL)emptyFilter
                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif




































































