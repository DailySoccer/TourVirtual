//
//  MDPAchievementsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 28/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPAchievementsHandlerProtocol_h
#define MDPClient_MDPAchievementsHandlerProtocol_h

#import "MDPPagedAchievementConfigurationTypeModel.h"
#import "MDPAchievementConfigurationModel.h"
#import "MDPAchievementModel.h"
#import "MDPAchievementConfigurationTypeModel.h"


#pragma mark - Response
typedef void (^MDPAchievementsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPAchievementsHandlerProtocol
@protocol MDPAchievementsHandlerProtocol <NSObject>

/*
 Gets the list of achievements of a determinate type availables for a client app.
 */
+ (void)getAchivementsWithAchievementConfigurationType:(NSString *)achievementConfigurationType
                                              language:(NSString *)language
                                       completionBlock:(MDPAchievementsHandlerResponseBlock)completionBlock;

/*
 Gets the list of achievements types.
 */
+ (void)getAchivementsTypeWithCt:(uint)ct
                        language:language
                 completionBlock:(void(^)(MDPPagedAchievementConfigurationTypeModel *contentResults, NSError *error))completionBlock;

/*
Gets a achievement configuration type by his id
 */
+ (void)getAchivementTypeByIdWithType:(NSString *)type
                             language:language
                      completionBlock:(void(^)(MDPAchievementConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Gets the list of achievements availables for a client app.
 */
+ (void)getAchievementConfigurationsByIdClientWithLanguage:(NSString *)language
                                           completionBlock:(MDPAchievementsHandlerResponseBlock)completionBlock;

/*
 Gets the list of achievements of a determinate type availables for a client app with info about fan has the achievements.
 */
+ (void)getFanAchievementsConfigurationWithType:(NSString *)achievementConfigurationType
                                       language:(NSString *)language
                                completionBlock:(MDPAchievementsHandlerResponseBlock)completionBlock;


/*
 Listens to MDPAchievementConfigurationModel objects
 */
+ (NSFetchedResultsController *)achievementConfigurationFetchedResultsControllerWithIdType:(NSString *)idType delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (MDPAchievementConfigurationModel *)achievementConfigurationWithIdAchievement:(NSString *)idAchievement level:(NSNumber *)level delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Find achievementConfiguration
 */
+ (MDPAchievementConfigurationModel *)achievementConfigurationWithIdAchievement:(NSString *)idAchievement level:(uint)level;

+ (NSMutableDictionary *)achievementConfigurationTypeWithLanguage:(NSString *)language;

+ (NSFetchedResultsController *)achievementConfigurationTypeFetchedResultsControllerWithIdType:(NSString *)idType delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif
