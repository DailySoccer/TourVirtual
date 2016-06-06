//
//  _MDPLanguageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLanguageModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLanguageModelAttributes {
	__unsafe_unretained NSString *languageCode;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPLanguageModelAttributes;

extern const struct MDPLanguageModelRelationships {
	__unsafe_unretained NSString *descriptionLanguage;
} MDPLanguageModelRelationships;

@class MDPLocaleDescriptionModel;

@interface _MDPLanguageModel : NSManagedObject

@property (nonatomic, strong) NSString* languageCode;

//- (BOOL)validateLanguageCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionLanguage;

- (NSMutableSet*)descriptionLanguageSet;

@end

@interface _MDPLanguageModel (DescriptionLanguageCoreDataGeneratedAccessors)
- (void)addDescriptionLanguage:(NSSet*)value_;
- (void)removeDescriptionLanguage:(NSSet*)value_;
- (void)addDescriptionLanguageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionLanguageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPLanguageModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveLanguageCode;
- (void)setPrimitiveLanguageCode:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveDescriptionLanguage;
- (void)setPrimitiveDescriptionLanguage:(NSMutableSet*)value;

@end
