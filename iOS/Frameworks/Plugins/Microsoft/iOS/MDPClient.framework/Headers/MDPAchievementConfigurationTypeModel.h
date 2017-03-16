//
//  MDPAchievementConfigurationTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAchievementConfigurationTypeModel.h"


#pragma mark - Interface
@interface MDPAchievementConfigurationTypeModel : _MDPAchievementConfigurationTypeModel

+ (MDPAchievementConfigurationTypeModel *)achievementConfigurationTypeWithType:(NSString *)type language:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsAchievementTypesWithDictionary:(NSDictionary *)dictionary language:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)achievementConfigurationTypeWithLanguage:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSMutableDictionary *)achievementConfigurationTypeWithLanguage:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

@end
