//
//  MDPAchievementConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAchievementConfigurationModel.h"


#pragma mark - Interface
@interface MDPAchievementConfigurationModel : _MDPAchievementConfigurationModel

+ (NSArray *)achievementsWithAchievementConfigurationType:(NSString *)achievementConfigurationType
                                     managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsAchievementConfigurationWithDictionary:(NSDictionary *)dictionary
                                                   managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)achievementConfigurationFetchedResultsControllerWithIdType:(NSString *)idType
                                                                      managedObjectContext:(NSManagedObjectContext *)context
                                                                                  delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (MDPAchievementConfigurationModel *)achievementConfigurationWithIdAchievement:(NSString *)idAchievement
                                                                          level:(NSNumber *)level
                                                           managedObjectContext:(NSManagedObjectContext *)context
                                                                       delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (MDPAchievementConfigurationModel *)achievementConfigurationWithIdAchievement:(NSString *)idAchievement
                                                                          level:(uint)level
                                                           managedObjectContext:(NSManagedObjectContext *)context;

@end
